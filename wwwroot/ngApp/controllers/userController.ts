namespace SkinApp.Controllers {
    export class UserController {
        public user;

        constructor(private userService: SkinApp.Services.UserService) {
            this.user = userService.getCurrentUser();  //gets all of the current user's information from the server
        }
    }

    export class AdminController {
        public users;
        public posts;

        constructor(private adminServices: SkinApp.Services.AdminServices,
            private skinServices: SkinApp.Services.SkinServices) {
            this.users = adminServices.getAllUsers();  //gets a list of all users
            this.getPosts(); //gets a list of all forum posts
        }
        //gets a list of all forum posts to display in admin page
        getPosts() {
            this.skinServices.getPosts().then((data) => {
                this.posts = data;
            })
        }
        //deletes a user specificed by userId
        deleteUser(userId) {
            this.adminServices.deleteUser(userId);
        }
        //deletes a forum post specified by the post's id
        adminDeletePost(postId) {
            this.adminServices.adminDeletePost(postId).then(() => {
            });
        }
    }
}