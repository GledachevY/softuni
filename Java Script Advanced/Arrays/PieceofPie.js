function myFunc (arr, start, end){
    let startIndex = arr.indexOf(start);
    let endIndex = arr.indexOf(end);

    const result = arr.slice(startIndex, endIndex + 1);
    return result;
}

console.log(myFunc(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
));