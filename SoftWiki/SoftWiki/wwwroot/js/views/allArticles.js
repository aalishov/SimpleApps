import { html } from 'https://unpkg.com/lit-html?module';
import { getAllArticles} from '../api/data.js'


const allAtticlesTemplate = (data) => html`
        <section id="catalog-page" class="content catalogue">
        ${data ?html` <h1>All Articles</h1>`: ""}
        ${data.length>0 ?  data.map(e => itemTemplate(e)) : 
            html`<h3 class="no-articles">No articles yet</h3>`}
        </section>
        `

const itemTemplate = (item) => html`
            <a class="article-preview" href=${`/details/${item._id}`}>
                <article>
                    <h3>Topic: <span>${item.title}</span></h3>
                    <p>Category: <span>${item.category}</span></p>
                </article>
            </a>
`


export async function allArticlesPage(ctx) {
    console.log('All aricles page');
    const data = await getAllArticles();
    ctx.render(allAtticlesTemplate(data));
}