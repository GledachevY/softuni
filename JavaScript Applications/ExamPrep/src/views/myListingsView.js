import { html } from '../../node_modules/lit-html/lit-html.js';
import { getMyListings } from '../api/data.js'

const myListingsHtml = (data) => html`<!-- My Listings Page -->
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">

        <!-- Display all records -->
        ${(data.length > 0 ? data.map(d => html`<div class="listing">
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
                    <a href="${`/data/cars/${d._id}`}" class="button-carDetails">Details</a>
                </div>
            </div>
        </div>`):html`<p class="no-cars"> You haven't listed any cars yet.</p>`)}
    </div>
</section>
`;

export async function myListing(ctx) {
    const myListingsFromServer = await getMyListings();

    ctx.render(myListingsHtml(myListingsFromServer));
}