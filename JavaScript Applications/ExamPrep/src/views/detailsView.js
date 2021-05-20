import { html } from '../../node_modules/lit-html/lit-html.js';
import {getListingById, deleteListing} from '../api/data.js'

const htmlElement = (data,id,onDelete) => html`<!-- Listing Details Page -->
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src=${data.imageUrl}>
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${data.brand}</li>
            <li><span>Model:</span>${data.model}</li>
            <li><span>Year:</span>${data.year}</li>
            <li><span>Price:</span>${data.price}$</li>
        </ul>

        <p class="description-para">${data.description}</p>

        ${(data._ownerId == sessionStorage.getItem('userId')? html`<div class="listings-buttons">
            <a href=${`/editListing/${id}`} class="button-list">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="button-list">Delete</a>
        </div>`:'')}
        
    </div>
</section>`

export async function details(ctx) {
    const id = ctx.params.id;
    const data =await getListingById(id);
    
    ctx.render(htmlElement(data,id, onDelete));

    async function onDelete(e){
        await deleteListing(id);
        ctx.page.redirect('/allListings');
    }
}