SELECT INFORMATION_SCHEMA.COLUMNS.*,
	COL_LENGTH('#TableName#', INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME) AS COLUMN_LENGTH,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsComputed') as IS_COMPUTED,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsIdentity') as IS_IDENTITY,
	COLUMNPROPERTY(OBJECT_ID('#TableName#'), INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME, 'IsRowGuidCol') as IS_ROWGUIDCOL
FROM INFORMATION_SCHEMA.COLUMNS
WHERE INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = '#TableName#'
