//import { page } from '../node_modules/page/page.mjs';
import page from "//unpkg.com/page/page.mjs";

import { render } from 'https://unpkg.com/lit-html?module';

import { logout } from '../js/api/data.js';

import { loginPage } from '../js/views/login.js';
import { registerPage } from '../js/views/register.js';
import { allArticlesPage } from '../js/views/allArticles.js';
import { homePage } from '../js/views/home.js';
import { createPage } from '../js/views/create.js';
import { detailsPage } from '../js/views/details.js';
import { editPage } from '../js/views/edit.js';

page('/', decorateContext, homePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/all', decorateContext, allArticlesPage);
page('/create', decorateContext, createPage);
page('/details/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);

const main = document.getElementById('main-content');

setUserNav();

document.getElementById('logoutBtn').addEventListener('click', logout);

// Start application
page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.setUserNav = setUserNav;
    next();
}

function setUserNav() {
    const userId = sessionStorage.getItem('userId');
    if (userId != null) {
        //console.log('user');
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    }
    else {
        //console.log('guest');
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}

document.getElementById('logoutBtn').addEventListener('click', async () => {
    await logout();
    setUserNav();
    page.redirect('/');
});