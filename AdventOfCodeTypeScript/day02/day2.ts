import * as fs from 'fs';

console.log("START DAY2 SCRIPT");

const filePath: string = 'day02/test-input.txt';
const content: string = fs.readFileSync(filePath, 'utf-8');

const lines = content.split(',');

// Foreach line
for(var i=0; i<lines.length; i++) {
    var line = lines[i];
    var strippedLine = line.split("-");

    var start = strippedLine[0];
    var end = strippedLine[1];
    
    var currentNumber = start;
    while(currentNumber != end) {
        console.log("ABANDON SHIP C#");
    }

}

console.log("END DAY2 SCRIPT");