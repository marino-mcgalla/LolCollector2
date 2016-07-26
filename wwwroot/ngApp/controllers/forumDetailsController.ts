namespace SkinApp.Controllers {

    export class ForumDetailsController {
        public postId;
        public post;
        public reply;
        public user;

        constructor(private skinServices: SkinApp.Services.SkinServices,
            private accountService: SkinApp.Services.AccountService,
            private $state: angular.ui.IStateService,
            $stateParams: angular.ui.IStateParamsService
        ) {
            this.postId = $stateParams["id"]; //gets the post's id from the state params (url address)
            this.getPost(); //gets the forum post that the user selected based on post id
            this.getUserName(); //gets the username of the current user
        }
        //gets the forum post that the user selected based on post id
        getPost() {
            this.skinServices.getPost(this.postId).then((data) => {
                this.post = data;
            });
        }
        //calls getPost() and then saves a reply to that post
        saveReply() {
            this.skinServices.saveReply(this.postId, this.reply).then(() => {
                this.getPost();
                let element: any = document.getElementById("replyForm");
                element.reset();
            });
        }
        //gets the username of the current user
        getUserName() {
            this.user = this.skinServices.getCurrentUser();
        }
        //returns the user to the previous page from the details page
        cancel() {
            this.$state.go("forum");
        }
    }
}
