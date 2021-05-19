import {html} from '../../node_modules/lit-html/lit-html.js';
import {getAllListings} from '../api/data.js'

const htmlElement = (data) =>  html`<!-- All Listings Page -->
<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">

        <!-- Display all records -->
        ${data.map(d => html`<div class="listing">
            <div class="preview">
                <img src=${d.imageUrl}>
            </div>
            <h2>${d.brand} ${d.model}</h2>
            <div class="info">
                <div class="data-info">
                    <h3>Year: ${d.year}</h3>
                    <h3>Price: ${d.price} $</h3>
                </div>
                <div class="data-buttons">
                    <a href=${`/data/cars/${d._id}`} class="button-carDetails">Details</a>
                </div>
            </div>
        </div>`)}
 
        <!-- Display if there are no records -->
        ${(data.length == 0 ? html`<p class="no-cars">No cars in database.</p> `: '')}
        
    </div>
</section>`;

export async function allListing(ctx){
    const data =await getAllListings();
    ctx.render(htmlElement(data));
}