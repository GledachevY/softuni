function myFunc(input){
    let obj = {};
    for (let index = 0; index < input.length; index++) {
        
        if(index % 2 === 0){
            obj[input[index]];
        }else{
            obj[input[index - 1]] = Number(input[index]); 
        }
    }
    console.log(obj);
}