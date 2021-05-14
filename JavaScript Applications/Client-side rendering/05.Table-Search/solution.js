import { render, html } from '../node_modules/lit-html/lit-html.js';

async function solve() {

   renderData(await getData());

   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick(event) {
      const trElements = event.target.parentNode.parentNode.parentNode.parentNode.querySelectorAll('tbody tr');
      const trArray = Array.from(trElements);
      trArray.forEach(m=> m.className = '');

      const textValues = {};

      trElements.forEach(el => el.querySelectorAll('td').
      forEach(td => textValues[el.id] == undefined?  textValues[el.id] =td.textContent.toLowerCase()+ ' ': textValues[el.id] +=td.textContent.toLowerCase()+ ' '));

      const match = document.getElementById('searchField').value.toLowerCase();
      if(match == ''){
         throw new Error;
      }
      document.getElementById('searchField').value = '';

      const idToMark = Object.entries(textValues).filter(el => el[1].includes(match));

      const markedIdsArray = [];

      idToMark.forEach(i=> markedIdsArray.push(i[0]));
      const markedtrs =[];

      for(let id of markedIdsArray){
         for(let tr of trArray){
            if(tr.id == id){
               markedtrs.push(tr);
            }
         }
      }
      markedtrs.forEach(m=> m.className = 'select');

   }
}
solve();

async function getData() {
   const response = await fetch(' http://localhost:3030/jsonstore/advanced/table');
   const data = await response.json();

   return data;
}

function renderData(data) {

   const dataAsArray = Object.values(data);

   const element = (d) => html`
   <tr id='${d._id}'>
      <td>${d.firstName} ${d.lastName}</td>
      <td>${d.email}</td>
      <td>${d.course}</td>
   </tr>
   `;

   const tbodyElements = dataAsArray.map(element);

   const tbodyElement = document.querySelector('tbody');


   render(tbodyElements, tbodyElement);
}