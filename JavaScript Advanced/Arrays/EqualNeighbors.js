function myFunc(matrix){
    let occur = 0;

    for(let i = 0; i < matrix.length - 1; i++){
        for(let p = 0; p< matrix[i].length - 1;p++){
            if(matrix[i][p] === matrix[i+ 1][p] || 
                matrix[i][p] === matrix[i][p + 1] || 
                matrix[i][p+ 1] === matrix[i +1][matrix[i].length - p - 2]){
                occur++;
            }
        }
    }

    return occur;
}




console.log(myFunc([
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]

));