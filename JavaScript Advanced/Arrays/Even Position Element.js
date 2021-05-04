function myFunc (arr){
    let result = '';
    for(let i = 0; i < arr.length; i+=2){
        result += arr[i] + ' ';
    }
    return result;
}

