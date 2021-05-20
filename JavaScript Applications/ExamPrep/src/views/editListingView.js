import {html} from '../../node_modules/lit-html/lit-html.js';
import {editListing as edit, getListingById} from '../api/data.js';

const editHtml = (listing, onSubmit) => html`
<!-- Edit Listing Page -->
<section id="edit-listing">
    <div class="container">

        <form @submit=${onSubmit} id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" .value=${listing.brand}>

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" .value=${listing.model}>

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" .value=${listing.description}>

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" .value=${listing.year}>

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" .value=${listing.imageUrl}>

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" .value=${listing.price}>

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>
`

export async function editListing(ctx){
    const id = ctx.params.id;
    const listing = await getListingById(id); 

    ctx.render(editHtml(listing, onSubmit));

    async function onSubmit(e){
        e.preventDefault();

        const form = new FormData(e.target);
        const brand = form.get('brand');
        const model = form.get('model');
        const description = form.get('description');
        const year = form.get('year');
        const imageUrl = form.get('imageUrl');
        const price = form.get('price');

        await edit(id, {brand, model,description, year,imageUrl,price});

        ctx.page.redirect('/data/cars/'+ id);
    }
}