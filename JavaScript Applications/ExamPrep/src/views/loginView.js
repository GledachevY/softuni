import {html} from '../../node_modules/lit-html/lit-html.js';
import {login} from '../api/data.js';

const loginHtml = (onSubmit) => html`<!-- Login Page -->
<section id="login">
    <div class="container">
        <form @submit=${onSubmit} id="login-form" action="#" method="post">
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr>

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text">

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn" value="Login">
        </form>
        <div class="signin">
            <p>Dont have an account?
                <a href="#">Sign up</a>.
            </p>
        </div>
    </div>
</section>`

export function logIn(ctx){

    ctx.render(loginHtml(onSubmit));

    async function onSubmit(e){
        e.preventDefault();

        const form = new FormData(e.target);

        const username = form.get('username');
        const password = form.get('password');

        await login(username, password);

        ctx.SetNavBar();
        ctx.page.redirect('/');
    }
}