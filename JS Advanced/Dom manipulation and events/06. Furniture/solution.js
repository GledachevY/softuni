function solve() {
  document.getElementById('container').addEventListener('click', onClick);

  function onClick(event) {

    const btn = event.target;
    if (btn.tagName === 'BUTTON') {
      if (btn.textContent === 'Generate') {
        const arrText = document.querySelector('#container textarea').value;
        const arrObjects = JSON.parse(arrText);
        const tBodyElement = document.querySelector('tbody');

        for (const element of arrObjects) {

          const trElement = document.createElement('tr');

          const tdElement1 = document.createElement('td');
          const imgElelement = document.createElement('img');
          imgElelement.src = element.img;
          tdElement1.appendChild(imgElelement);

          const tdElement2 = document.createElement('td');
          const nameElement = document.createElement('p');
          nameElement.textContent = element.name;
          tdElement2.appendChild(nameElement);

          const tdElement3 = document.createElement('td');
          const priceElement = document.createElement('p');
          priceElement.textContent = element.price;
          tdElement3.appendChild(priceElement);

          const tdElement4 = document.createElement('td');
          const decFactorlement = document.createElement('p');
          decFactorlement.textContent = element.decFactor;
          tdElement4.appendChild(decFactorlement);

          const tdElement5 = document.createElement('td');
          const checkElement1 = document.createElement('input');
          checkElement1.type = 'checkbox';
          tdElement5.appendChild(checkElement1);


          trElement.appendChild(tdElement1);
          trElement.appendChild(tdElement2);
          trElement.appendChild(tdElement3);
          trElement.appendChild(tdElement4);
          trElement.appendChild(tdElement5);

          tBodyElement.appendChild(trElement);

        }


      } else if (btn.textContent === 'Buy') {
        const textAreaResult = document.querySelectorAll('textArea')[1];
      
        const checkboxes = Array.from(document.querySelectorAll('input'));
        const furnitureElements = [];
        for (const chekcbox of checkboxes) {
          if (chekcbox.checked === true) {
            const pis = Array.from(chekcbox.parentNode.parentNode.querySelectorAll('p'));
            const nameFurniture = pis[0].textContent;
            const priceFurniture = Number(pis[1].textContent);
            const decFacFurniture = Number(pis[2].textContent);

            furnitureElements.push({nameFurniture, priceFurniture, decFacFurniture});
          }
        }
        const resultElement = furnitureElements.reduce((acc,cur) =>{
          acc.names.push(cur.nameFurniture);
          acc.priceSum += cur.priceFurniture;
          acc.decFacSum += cur.decFacFurniture;
          return acc;
        }, {names:[], priceSum:0, decFacSum:0});

        textAreaResult.value = `Bought furniture: ${resultElement.names.join(', ')} 
Total price: ${resultElement.priceSum.toFixed(2)}
Average decoration factor: ${(resultElement.decFacSum / resultElement.names.length).toFixed(1)} `;
      }
    }
  }
}