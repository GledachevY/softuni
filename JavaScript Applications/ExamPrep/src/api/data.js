import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const logout = api.logout;
export const register = api.register;

//custom reùests

export async function getAllListings(){
    return await api.get('/data/cars?sortBy=_createdOn%20desc');
}

export async function getListingById(id){
    return await api.get('/data/cars/' + id);
}

export async function getMyListings(){
    const data = await getAllListings();

    const userId = sessionStorage.getItem('userId');

    const myListings = data.filter(l => l._ownerId == userId);
    return myListings;
}

export async function getListingsByYear(year){
    const data = await getAllListings();

    return data.filter(l => l.year == year);
}

export async function createListing(data){
    return await api.post('/data/cars',data);
}

export async function editListing(id,data){
    return await api.put('/data/cars/' + id, data);
}

export async function deleteListing(id){
    return await api.del('/data/cars/' + id);
}