import { html } from '../../node_modules/lit-html/lit-html.js';
import { register as reg } from '../api/data.js';

const registerElement = (onClick) => html`<!-- Register Page -->
<section id="register">
    <div class="container">
        <form @submit=${onClick} id="register-form">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr>

            <p>Username</p>
            <input type="text" placeholder="Enter Username" name="username" required>

            <p>Password</p>
            <input type="password" placeholder="Enter Password" name="password" required>

            <p>Repeat Password</p>
            <input type="password" placeholder="Repeat Password" name="repeatPass" required>
            <hr>

            <input type="submit" class="registerbtn" value="Register">
        </form>
        <div class="signin">
            <p>Already have an account?
                <a href="#">Sign in</a>.
            </p>
        </div>
    </div>
</section>`

export function register(ctx) {
    ctx.render(registerElement(onClick));

    async function onClick(e) {
        e.preventDefault();
        const form = new FormData(e.target);
    
        const username = form.get('username');
        const pass = form.get('password');;
    
        await reg(username, pass);

        ctx.SetNavBar();
    
        ctx.page.redirect('/');
    }
}
