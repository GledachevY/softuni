function solve() {
  const input = document.getElementById('input').value;
  const output = document.getElementById('output');

  function onlyUnique(value, index, self) {
    return self.indexOf(value) === index;
  }

  let arrayOfSentences = input.split('.');
  arrayOfSentences.forEach(sentence => {
      if(sentence.length <= 1){
        arrayOfSentences.pop(sentence);
      }
  });

  arrayOfSentences = arrayOfSentences.filter(onlyUnique);
  console.log(arrayOfSentences)

  for (let i = 0; i < arrayOfSentences.length; i++) {
    if(arrayOfSentences[i] === ''){
      continue;
    }
    else if (i % 3 === 0 || i === 0) {
      output.innerHTML += `<p> ${arrayOfSentences[i] + '.'} </p>`;
    }else{
      const paragraph = document.querySelector('body #output p:last-child');
      paragraph.textContent += arrayOfSentences[i] + '. ';
    }
  }
  const resultParagraph = document.querySelector('body #output p:last-child').textContent;
  resultParagraph.substring(0, )
}