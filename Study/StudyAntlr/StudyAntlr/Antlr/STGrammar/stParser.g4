grammar stParser;

UNDER_SCORE_F: '_';
IF: I F;
THEN: T H E N;
ELSEIF: E L S E ' ' I F;
ELSE: E L S E;
SEMICORON: ';';
END_IF: END_PREFIX IF;
ANY_SYM: (~([IF] | [END_IF] | [THEN]))+;

//ifBlock:IF (ANY_SYM | ifBlock)* END_IF;

//そこそこちゃんととれる
//ifBlock:IF ANY_SYM THEN (ifBlock)* END_IF;

ifBlock: IF condition+=ANY_SYM THEN proc+=ANY_SYM (ifBlock)*
         (ELSEIF condition+=ANY_SYM THEN proc+= ANY_SYM (ifBlock)*)*
         (ELSE condition+=ANY_SYM (ifBlock)* END_IF)?
         END_IF SEMICORON;
expr: ifBlock+;
WS: [\t\r\n] -> skip;

// fragment
fragment END_PREFIX: E N D UNDER_SCORE_F;
fragment A: 'A' | 'a';
fragment B: 'B' | 'b';
fragment C: 'C' | 'c';
fragment D: 'D' | 'd';
fragment E: 'E' | 'e';
fragment F: 'F' | 'f';
fragment G: 'G' | 'g';
fragment H: 'H' | 'h';
fragment I: 'I' | 'i';
fragment J: 'J' | 'j';
fragment K: 'K' | 'k';
fragment L: 'L' | 'l';
fragment M: 'M' | 'm';
fragment N: 'N' | 'n';
fragment O: 'O' | 'o';
fragment P: 'P' | 'p';
fragment Q: 'Q' | 'q';
fragment R: 'R' | 'r';
fragment S: 'S' | 's';
fragment T: 'T' | 't';
fragment U: 'U' | 'u';
fragment V: 'V' | 'v';
fragment W: 'W' | 'w';
fragment X: 'X' | 'x';
fragment Y: 'Y' | 'y';
fragment Z: 'Z' | 'z';

