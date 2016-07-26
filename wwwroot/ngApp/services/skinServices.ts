namespace SkinApp.Services {

    export class SkinServices {
        private postResources;
        private replyResources;
        private userResources;

        constructor($resource: angular.resource.IResourceService) {
            this.postResources = $resource('/api/forum/:id');
            this.replyResources = $resource('/api/reply/:id');
            this.userResources = $resource('/api/user/:id', null, {
                //custom methods
                GetCurrentUser: {
                    method: 'GET',
                    url: '/api/user/getcurrentuser',
                }
            });
        }
        //gets a list of all posts
        getPosts() {
            return this.postResources.query().$promise;
        }
        //gets a single post specificed by postId passed from the view
        getPost(postId) {
            var post = this.postResources.get({ id: postId }).$promise;
            return post;
        }
        //saves a forum post
        savePost(post) {
            return this.postResources.save(post).$promise;
        }
        //saves a reply to a forum post
        saveReply(postId, reply) {
            return this.replyResources.save({ id: postId }, reply).$promise;
        }
        //deletes a forum post
        deletePost(postId) {
            return this.postResources.delete({ id: postId }).$promise;
        }
        //gets currently logged in user
        getCurrentUser() {
            return this.userResources.GetCurrentUser();
        }
        //saves selected skins
        saveSkins(userId, skins) {
            return this.userResources.save({ id: userId }, skins).$promise;
        }
    }
    angular.module('SkinApp').service('skinServices', SkinServices);
}