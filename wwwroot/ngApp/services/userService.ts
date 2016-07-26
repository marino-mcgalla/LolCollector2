namespace SkinApp.Services {

    export class UserService {
        private userResource;

        constructor($resource: angular.resource.IResourceService) {
            this.userResource = $resource('/api/user/:id', null, {
                //custom methods
                GetCurrentUser: {
                    method: 'GET',
                    url: '/api/user/getcurrentuser',
                }
            });
        }
        //gets currently logged in user
        getCurrentUser() {
            return this.userResource.GetCurrentUser();
        }
    }
    angular.module('SkinApp').service('userService', UserService);
}