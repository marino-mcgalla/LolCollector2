namespace SkinApp.Controllers {

    export class ForumController {
        public posts;

        constructor(private skinServices: SkinApp.Services.SkinServices, private accountService: SkinApp.Services.AccountService, private $state: angular.ui.IStateService) {
            this.getPosts(); //gets all forum posts to display on the forum page
        }
        //gets all forum posts to display on the forum page
        getPosts() {
            this.skinServices.getPosts().then((data) => {
                this.posts = data;
            });
        }

        //getProfile(userId) {
        //    this.skinServices.getProfile(userId);
        //}

    }
}