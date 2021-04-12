import * as api from './api.js';

const host = 'https://localhost:5001/api';

api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllArticles() {
    return await api.get(host + '/articles/all');
}

export async function getAllCategories() {
    return await api.get(host + '/articles');
}

export async function addItem(item) {
    return await api.post(host + '/articles', item);
}

export async function getItem(id) {
    return await api.get(host + '/articles' + id);
}

export async function editItem(id, item) {
    return await api.put(host + '/articles' + id, item);
}

export async function deleteItem(id) {
    return await api.del(host + '/articles' + id);
}