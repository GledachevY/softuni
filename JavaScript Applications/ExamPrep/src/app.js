import page from '../node_modules/page/page.mjs';
import { render } from '../node_modules/lit-html/lit-html.js'
import * as api from './api/data.js';

import { homePage } from './views/homeView.js'
import { allListing } from './views/allListingView.js'
import { byYear } from './views/byYearView.js'
import { createListing } from './views/createListingView.js'
import { logIn } from './views/loginView.js'
import { myListing } from './views/myListingsView.js'
import { register } from './views/registerView.js'
import { details } from './views/detailsView.js'

window.api = api;

const containeer = document.getElementById('site-content');
const userNav = document.getElementById('profile');
const guestNav = document.getElementById('guest');
document.getElementById('logoutBtn').addEventListener('click', onclick);

page('/', renderMiddleware, homePage);
page('/allListings', renderMiddleware, allListing);
page('/byYear', renderMiddleware, byYear);
page('/myListings', renderMiddleware, myListing);
page('/createListing', renderMiddleware, createListing);
page('/login', renderMiddleware, logIn);
page('/register', renderMiddleware, register);
page('/data/cars/:id', renderMiddleware, details);

SetNavBar();
page.start();


function renderMiddleware(ctx, next) {
    ctx.render = (content) => render(content, containeer);
    ctx.SetNavBar = SetNavBar;
    next();
}

function SetNavBar() {
    if (sessionStorage.length > 1) {
        userNav.style.display = 'inline-block';
        guestNav.style.display = 'none';
        userNav.querySelector('a').textContent = `Welcome ${sessionStorage.username}`;
    } else {
        userNav.style.display = 'none';
        guestNav.style.display = 'inline-block';
    }
}

async function onclick(e){
    await api.logout();
    SetNavBar();
    page.redirect('/');
}