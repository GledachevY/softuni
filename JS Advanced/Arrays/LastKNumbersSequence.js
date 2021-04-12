function myFunc(num1, num2) {
    const resultArr = [];
    resultArr.unshift(1);

    for (let p = 1; p < num1; p++) {

        resultArr.push(sumElements(resultArr));
    }

    function sumElements(arr) {
        let count = 0;
        let sum = 0;
        for (let i = arr.length - 1; i >= 0; i--) {
            count++;
            let element = arr[i];
            if (count > num2) {
                return sum;
            }
            sum += element
        }
        return sum;
    }

    return resultArr;
}


myFunc(6,2);