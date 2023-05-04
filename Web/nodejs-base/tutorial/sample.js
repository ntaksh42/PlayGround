'use strict'

const fs = require("fs");
const { read, write, readJson, writeJson } = require("./helper");

const req = process.argv[2];
if (req === "read") {
    read();
} else if (req === "readJson") {
    readJson();
} else if (req === "write") {
    if (process.argv.length < 4) {
        console.error("書き込み用の文字列を渡してください");
        return;
    }
    write(process.argv[3]);
} else if (req === "writeJson") {
    writeJson();
}
else {
    console.error("引数が不正");
}

