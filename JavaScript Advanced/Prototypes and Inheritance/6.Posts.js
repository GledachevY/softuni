function solution() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;

        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];

        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = `Post: ${this.title}\nContent: ${this.content}\nRaiting: ${this.likes - this.dislikes}`;
            if (this.comments.length > 0) {
                result += '\nComments:\n'
                this.comments.forEach((c) => result += `${c}\n`);
            }

            return result;
        }
    }

    class BlogPost  extends Post{
        constructor(title, content,views){
            super(title, content);
            this.views = views;
        }

        view(){
            this.views++;
            return this;
        }
        toString() {
            return `Post: ${this.title}\nContent: ${this.content}\nViews: ${this.views}`;
        }
    }

    return{Post, SocialMediaPost, BlogPost};
}

const classes = solution();


let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 5, 10);

scm.addComment('1');
scm.addComment('2');
scm.addComment('3');

console.log(scm.toString());
