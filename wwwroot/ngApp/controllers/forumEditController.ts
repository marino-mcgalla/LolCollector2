namespace SkinApp.Controllers {

    export class ForumEditController {
        public post;
        private postId;

        constructor(private skinServices: SkinApp.Services.SkinServices,
            private $state: angular.ui.IStateService,
            $stateParams: angular.ui.IStateParamsService
        ) {
            this.postId = $stateParams["id"];
            this.getPost();
        }
        //gets the forum post that the user selected based on post id
        getPost() {
            this.skinServices.getPost(this.postId).then((data) => { this.post = data});
        }
        //saves forum post
        savePost() {
            this.skinServices.savePost(this.post)
                .then(() => {
                    this.$state.go("forum")
                        .catch((data) => {
                        });
                });
        }
        //deletes forum post based on postId
        deletePost() {
            this.skinServices.deletePost(this.postId).then(() => {
                this.$state.go("forum");
            });
        }
        //returns user to the previous page from the delete page
        cancel() {
            this.$state.go("forum");
        }
    }
}