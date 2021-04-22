function myFunc(arr){
    const arrayToShow = [];
    for(let i = 1; i< arr.length; i+=2){
        arrayToShow.push(arr[i]);
    }

    
    const result =arrayToShow.map(a => a * 2);
    result.reverse();
    console.log(result.join(' '));
}

myFunc([3, 0, 10, 4, 7, 3]);