import { html } from 'https://unpkg.com/lit-html?module';

import { deleteItem, getItem } from '../api/data.js';


const detailsTemplate = (item, isOwner, onDelete,goBack) => html`
        <section id="details-page" class="content details">
            <h1>${item.title}</h1>
        
            <div class="details-content">
                <strong>Published in category ${item.category}</strong>
                <p>${item.content}</p>
        
                ${isOwner ? 
            html`<div class="buttons">
                    <a @click=${onDelete} href="javascript:void(0)" class="btn delete">Delete</a>
                    <a href=${`/edit/${item._id}`} class="btn edit">Edit</a>
                    <a @click=${goBack} href="javascript:void(0)" class="btn edit">Back</a>
                </div>`
             : ''}

                
            </div>
        </section>
`;

export async function detailsPage(ctx) {
    console.log('Details  page', ctx.params.id);
    const id = ctx.params.id;
    const item = await getItem(id);
    const userId = sessionStorage.getItem('userId');

    ctx.render(detailsTemplate(item, userId==item._ownerId, onDelete,goBack));

    async function onDelete() {
        const confirmed = confirm('Are you shure you want to delete this item!');
        if (confirmed) {
            await deleteItem(item._id);
            ctx.page.redirect('/');
        }
    }

   async function goBack() {
        window.history.back();
      }
}