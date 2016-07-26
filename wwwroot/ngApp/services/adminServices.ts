namespace SkinApp.Services {

    export class AdminServices {
        private userResource;
        private postResource;

        constructor($resource: angular.resource.IResourceService) {
            //custom methods
            this.userResource = $resource('/api/user/:id', null, {
                getAllUsers: {
                    method: 'GET',
                    url: '/api/user/getallusers',
                    isArray: true
                }
            });
            this.postResource = $resource('/api/user/:id', null, {
                adminDeletePost: {
                    method: 'DELETE',
                    url: '/api/user/admindeletepost/:id'
                }
            });
        }
        //gets all registered user to display in the admin page
        getAllUsers() {
            return this.userResource.getAllUsers();
        }
        //deletes a user from the database
        deleteUser(userId) {
            return this.userResource.delete({ id: userId }).$promise
        }
        //delets a forum post (admin can delete any post)
        adminDeletePost(postId) {
            return this.postResource.adminDeletePost({ id: postId }).$promise;
        }
    }
    angular.module('SkinApp').service('adminServices', AdminServices);
}