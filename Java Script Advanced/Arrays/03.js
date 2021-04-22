function myFunc(commands){
    resultArr = [];

    for(let index in commands){
        let numIndex = Number(index);
        let numberToAdd = Number(numIndex + 1);
        if(commands[index] === 'add'){
            resultArr.push(numberToAdd);
        }else{
            resultArr.pop();
        }
    }

    return resultArr.join('\n')
}

console.log(myFunc(['add', 
'add', 
'add', 
'add']
));