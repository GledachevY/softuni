function solve() {
  const textToEdit = document.getElementById('text').value;
  const typeOfEdit = document.getElementById('naming-convention').value;
  const spenResult = document.getElementById('result');

  let textArr = [];
  textArr = textToEdit.split(' ');
  let resultStr = '';
  function converStrToLower(arrOfStrings) {
    let result = arrOfStrings.map(string => string.toLowerCase());
    return result;
  }
  let lowerStr = converStrToLower(textArr);
  

  if (typeOfEdit === 'Camel Case') {
    resultStr = lowerStr.reduce((result, current) => result += current[0].toUpperCase() + current.substring(1));

  } else if (typeOfEdit === 'Pascal Case') {
    resultStr = lowerStr.reduce((result, current) => result += current[0].toUpperCase() + current.substring(1));
    resultStr = resultStr[0].toUpperCase() + resultStr.substring(1);
  } else {
    resultStr = 'Error!';
  }

  spenResult.textContent = resultStr;
}