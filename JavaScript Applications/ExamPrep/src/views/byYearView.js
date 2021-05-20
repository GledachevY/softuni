import { html } from '../../node_modules/lit-html/lit-html.js';
import { getListingsByYear } from '../api/data.js'

const byYearHtml = (onClick, data, isDataEmpty) => html`<!-- Search Page -->
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
        <button @click=${onClick} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>
    ${(!isDataEmpty ? data.map(d => html`<div class="listings">

        <!-- Display all records -->
        <div class="listing">
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
        </div>`) : html`<p class="no-cars"> No results.</p>`)}
    </div>
</section>
`;

export async function byYear(ctx) {
    let data;
    let isDataEmpty = true;
    ctx.render(byYearHtml(onClick, data, isDataEmpty));

    async function onClick(e) {
        const year = document.getElementById('search-input').value;
        data = await getListingsByYear(year);
        if(data.length > 0){
            isDataEmpty = false;
        }else{
            isDataEmpty = true;
        }
        ctx.render(byYearHtml(onClick, data, isDataEmpty));
    }
}