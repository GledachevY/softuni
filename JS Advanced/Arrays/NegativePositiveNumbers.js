function myFunc(arr){
    const resultArr = [];
    for(let i = 0; i < arr.length; i++){
        if(arr[i] < 0){
            resultArr.unshift(arr[i]);

        }else{
            resultArr.push(arr[i]);
        }
    }

    for(let num of resultArr){
        console.log(num);
    }
}

myFunc([7, -2, 8, 9]);