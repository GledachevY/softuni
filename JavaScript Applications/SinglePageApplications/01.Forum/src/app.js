import { addTopic } from './addTopic.js';
import { showTopics } from './showPost.js';

await addTopic();
await showTopics();

let date = Date.now();
date = new Date(date);
date = date.toDateString();

console.log(date);