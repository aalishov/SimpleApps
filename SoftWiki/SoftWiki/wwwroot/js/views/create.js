import { html } from 'https://unpkg.com/lit-html?module';

import { addItem } from '../api/data.js';

const createTemplate = (onSubmit) => html`
        <section id="create-page" class="content">
            <h1>Create Article</h1>
        
            <form id="create" action="#" method="" @submit=${onSubmit}>
                <fieldset>
                    <p class="field title">
                        <label for="create-title">Title:</label>
                        <input type="text" id="create-title" name="title" placeholder="Enter article title">
                    </p>
        
                    <p class="field category">
                        <label for="create-category">Category:</label>
                        <input type="text" id="create-category" name="category" placeholder="Enter article category">
                    </p>
                    <p class="field">
                        <label for="create-content">Content:</label>
                        <textarea name="content" id="create-content"></textarea>
                    </p>
        
                    <p class="field submit">
                        <input class="btn submit" type="submit" value="Create">
                    </p>
        
                </fieldset>
            </form>
        </section>
`;

export async function createPage(ctx) {
    ctx.render(createTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);

        const title = formData.get('title').trim();
        const category = formData.get('category').trim();
        const content = formData.get('content').trim();

        if (!title || !category || !content) {
            //return showNotification('All fields are required!');
            return alert('All fields are required!');
        }
        if (!(category=='JavaScript'||category=='C#'||category=='Java'||category=='Python')) {
            return alert('The category must be one of "JavaScript", "C#", "Java", or "Python"');
        }

        const item = {
            title,
            category,
            content
        }

        await addItem(item);
        ctx.setUserNav();
        ctx.page.redirect('/');
    }
}