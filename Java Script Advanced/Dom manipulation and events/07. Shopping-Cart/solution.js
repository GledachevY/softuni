function solve() {

   const arr = [];
   const textarea = document.querySelector('div textarea');

   document.querySelector('.shopping-cart').addEventListener('click', (event) => {

      const name = event.target.parentNode.parentNode.querySelector('.product-title').textContent;
      const price = Number(event.target.parentNode.parentNode.querySelector('.product-line-price').textContent);

      if (event.target.tagName === 'BUTTON' && event.target.className === 'add-product') {
         
         textarea.textContent += `Added ${name} for ${price.toFixed(2)} to the cart. \n`
         arr.push({ name, price });
      }
   });



   document.querySelector('.checkout').addEventListener('click', () => {

      const resultSum = arr.reduce((acc, cur) => {
         if (acc.products.includes(cur.name)) {
            acc.sum += cur.price;
            return acc;

         } else {
            acc.products.push(cur.name);
            acc.sum += cur.price;
            return acc;

         }
      }, { products: [], sum: 0 });



      textarea.textContent += `You bought ${resultSum.products.join(', ')} for ${resultSum.sum.toFixed(2)}.`;
   })
}