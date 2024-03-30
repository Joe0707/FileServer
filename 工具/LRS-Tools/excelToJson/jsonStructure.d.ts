declare namespace JsonStructure {
	const enum Json_table_nameFields {
		field_1 = 0, /**字段1*/
		field_2 = 1, /**字段2*/
		field_3 = 2, /**字段3*/
		field_4 = 3, /**字段4*/
		field_5 = 4, /**字段5*/
	}
	type Json_table_name = [number, string, number[], number[][], any];

}