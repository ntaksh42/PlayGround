grammar nestParen;
tokens{
}

OPEN_PREN: '(';
CLOSE_PREN: ')';
ANY_SYM: (~('(' | ')'))+;

prenBlock:OPEN_PREN (ANY_SYM | prenBlock)* CLOSE_PREN;
expr: prenBlock+;
WS: [\t\r\n] ->skip;