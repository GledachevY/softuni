function myFunc(matrix) {
    const nestedArr = [];
    for (let item of matrix) {
        for (let num of item) {
            nestedArr.push(num);
        }
    }

    let result = nestedArr.reduce(function (acc, curr) {
        return acc >= curr ? acc : curr;
    });

    return result;
}

console.log(myFunc([[-3, -5, -7, -12],
    [-1, -4, -33, -2],
    [-8, -3, -1, -4]]));
   