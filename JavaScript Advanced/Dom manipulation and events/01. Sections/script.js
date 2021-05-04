function create(words) {
   const content = document.querySelector('#content');
   content.addEventListener('click', onClick);

   for (const word of words) {
      const div = document.createElement('div');
      const paragraph = document.createElement('p');
      paragraph.textContent = word;
      div.appendChild(paragraph);
      content.appendChild(div);
      paragraph.style.display = 'none';
   }

   function onClick(event){
     event.target.querySelector('p').style.display='block';
   }

}