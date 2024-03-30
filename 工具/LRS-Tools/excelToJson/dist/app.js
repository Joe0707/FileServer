"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (Object.hasOwnProperty.call(mod, k)) result[k] = mod[k];
    result["default"] = mod;
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
const node_xlsx_1 = __importDefault(require("node-xlsx"));
const path = __importStar(require("path"));
const fs = __importStar(require("fs"));
const app_root_path_1 = __importDefault(require("app-root-path"));
const config_json_1 = __importDefault(require("./config.json"));
class ExcelToJson {
    constructor(inputPath, outPath, dtsOutPath) {
        this.inputPath = inputPath;
        this.outPath = outPath;
        this.dtsOutPath = dtsOutPath;
        this.typeFnHash = new Map();
        this.dtsHash = new Map();
        this.logHash = new Map();
        this.typeFnHash.set("string", { type: "string", build: (data = "") => data });
        this.typeFnHash.set("int", { type: "number", build: (data = "0") => {
                return Number(data);
            } });
        this.typeFnHash.set("int[]", { type: "number[]", build: (data = "") => {
                let nums = data.split(","), res = [];
                for (let i of nums) {
                    res.push(this.typeFnHash.get("int").build(i));
                }
                return res;
            } });
        this.typeFnHash.set("int[][]", { type: "number[][]", build: (data = "") => {
                let arrays = data.split(";"), res = [];
                for (let i of arrays) {
                    res.push(this.typeFnHash.get("int[]").build(i));
                }
                return res;
            } });
        this.typeFnHash.set("json", { type: "any", build: (data = "{}") => {
                return JSON.parse(data);
            } });
        this.inputPath = path.join(app_root_path_1.default.path, this.inputPath);
        this.dtsOutPath = path.join(app_root_path_1.default.path, this.dtsOutPath);
        this.outPath = this.outPath.map((i) => path.join(app_root_path_1.default.path, i));
    }
    initConfig(sheet, fileName) {
        let serverExport = [sheet.data[0], []], clientExport = [sheet.data[1], []], names = sheet.data[2], notes = sheet.data[3], data = sheet.data.slice(4).filter((i) => !!i[0]);
        for (let i = 0; i < serverExport[0].length; i++) {
            if (this.typeFnHash.has(serverExport[0][i])) {
                serverExport[1].push(i);
            }
        }
        for (let i = 0; i < clientExport[0].length; i++) {
            if (this.typeFnHash.has(clientExport[0][i])) {
                clientExport[1].push(i);
            }
        }
        return [{
                serverExport,
                clientExport,
                notes,
                names,
                fileName,
            }, data];
    }
    buildJson(data, config, type) {
        let res = {};
        for (let i = 0; i < data.length; i++) {
            let temp = {};
            for (let fieldIndex of config[type][1]) {
                temp[config.names[fieldIndex]] = this.typeFnHash.get(config[type][0][fieldIndex]).build(data[i][fieldIndex]);
            }
            res[i] = temp;
        }
        let json = JSON.stringify(res, null, "\t"), name = `${config.names[0]}.json`, promiseList = [];
        for (let outputPath of this.outPath) {
            promiseList.push(new Promise((res, rej) => {
                fs.writeFile(`${path.join(outputPath, name)}`, json, (err) => {
                    if (err) {
                        console.log(err);
                        rej(err);
                    }
                    else {
                        this.dtsHash.set(config.names[0], config);
                        let array = this.logHash.get(config.fileName) || [];
                        array.push(config.names[0]);
                        this.logHash.set(config.fileName, array);
                        console.log(`output ${name}`);
                        res();
                    }
                });
            }));
        }
        return Promise.all(promiseList);
    }
    async buildDTS(type) {
        let logStr = "", contextStr = "declare namespace JsonStructure {\n%-replace-%}", replaceStr = "";
        for (let [key, val] of this.dtsHash) {
            let temp = `\tconst enum Json_${val.names[0]}Fields {\n%-fields-%\t}\n`, fieldsStr = "", typesStr = "";
            for (let i = 0; i < val[type][1].length; i++) {
                fieldsStr += `\t\t${val.names[val[type][1][i]]} = ${i}, /**${val.notes[val[type][1][i]]}*/\n`;
                typesStr += this.typeFnHash.get(val[type][0][val[type][1][i]]).type;
                if (i + 1 < val[type][1].length) {
                    typesStr += ", ";
                }
            }
            temp = temp.replace("%-fields-%", fieldsStr);
            temp += `\ttype Json_${val.names[0]} = [%-types-%];\n\n`;
            temp = temp.replace("%-types-%", typesStr);
            replaceStr += temp;
        }
        contextStr = contextStr.replace("%-replace-%", replaceStr);
        for (let [key, val] of this.logHash) {
            let temp = `${key} -> [%-tables-%]\n`, tablesStr = "";
            for (let i = 0; i < val.length; i++) {
                tablesStr += val[i];
                if (i + 1 < val.length) {
                    tablesStr += ", ";
                }
            }
            temp = temp.replace("%-tables-%", tablesStr);
            logStr += temp;
        }
        await Promise.all([
            new Promise((res, rej) => {
                fs.writeFile(path.join(this.dtsOutPath, "jsonStructure.d.ts"), contextStr, (err) => {
                    if (err) {
                        console.log(err);
                    }
                    res();
                });
            }),
            new Promise((res, rej) => {
                fs.writeFile(path.join(this.dtsOutPath, "log.txt"), logStr, (err) => {
                    if (err) {
                        console.log(err);
                    }
                    res();
                });
            }),
        ]);
    }
    async buildTable(fileName) {
        let table = node_xlsx_1.default.parse(path.join(this.inputPath, fileName));
        for (let sheet of table) {
            if (sheet.data.length) {
                let [config, data] = this.initConfig(sheet, fileName);
                if (data.length) {
                    await this.buildJson(data, config, "serverExport");
                    //this.buildJson(data, config, "clientExport");
                }
            }
        }
    }
    run() {
        fs.access(this.inputPath, async (err) => {
            if (err) {
                console.log(err);
            }
            else {
                let flag = true;
                for (let outputPath of this.outPath) {
                    if (flag) {
                        await new Promise((res, rej) => {
                            fs.access(outputPath, (err) => {
                                if (err && err.code == "ENOENT") {
                                    fs.mkdir(outputPath, { recursive: true }, (err) => {
                                        if (err) {
                                            console.log(err);
                                        }
                                        res();
                                    });
                                }
                                else {
                                    res();
                                }
                            });
                        });
                    }
                }
                if (flag) {
                    fs.readdir(this.inputPath, async (err, files) => {
                        if (err) {
                            console.log(err);
                        }
                        else {
                            let promiseList = [];
                            for (let file of files) {
                                if (!file.includes("~$")) {
                                    promiseList.push(this.buildTable(file));
                                }
                            }
                            await Promise.all(promiseList);
                            await this.buildDTS("serverExport");
                            //this.buildDTS("clientExport");
                        }
                    });
                }
            }
        });
    }
}
exports.ExcelToJson = ExcelToJson;
new ExcelToJson(config_json_1.default.inputPath, config_json_1.default.outputPaths, config_json_1.default.dtsOutputPath).run();
//# sourceMappingURL=app.js.map