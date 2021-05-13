import { contacts } from './contacts.js'
import { render, html } from '../node_modules/lit-html/lit-html.js';

function onclick(e){
   const deteailsElement = e.target.parentNode.querySelector('.details');
   const contact = contacts.find(c => c.id == deteailsElement.id);
   if(!contact.isVisible){
       deteailsElement.style.display = 'block';
       contact.isVisible = true;
   }else{
    deteailsElement.style.display = 'none';
    contact.isVisible = false;
   }
}

contacts.forEach(c => c.isVisible = false);

const result = (info) => html`
        <div class="contact card">
            <div>
                <i class="far fa-user-circle gravatar"></i>
            </div>
            <div class="info">
                <h2>Name: ${info.name}</h2>
                <button @click = ${onclick} class="detailsBtn">Details</button>
                <div class="details" id=${info.id}>
                    <p>Phone number: ${info.phoneNumber}</p>
                    <p>Email: ${info.email}</p>
                </div>
            </div>
        </div>
        `;

const elementToShow = contacts.map(result);

render(elementToShow, document.getElementById('contacts'));
