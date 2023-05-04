grammar sample;

input: (line? EOL+)* line? EOF;
line 
    :COMMENT
    |WS COMMENT
    |body (WS? COMMENT)?
    ;

body: TEXT;
WS: [\t]+;
EOL: '\r'? '\n' | '\r';
COMMENT: ';' ~[\r\n]*;
TEXT: ~[ \t;\r\n]+;

