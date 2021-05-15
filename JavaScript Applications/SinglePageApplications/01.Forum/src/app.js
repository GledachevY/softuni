import { addTopic, cancelBtn } from './addTopic.js';
import { showTopics } from './showPost.js';
import {addComment} from './addCommentOnTopic.js'

await addTopic();
await showTopics();
addComment();
cancelBtn();

