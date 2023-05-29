# SpecFlow-RestSharp Demo

## Feature File

A `Scenario Outline` with `Examples` table is used for data-driven testing.

```
@users
Feature: Users

	@get @listUsers
	Scenario Outline: ListUsers_FindByName_ReturnUser
		Given The list of users is requested
		When The name '<firstName>' '<lastName>' is searched
		Then The user exists

		Examples:
			| firstName | lastName |
			| Janet     | Weaver   |
			| Rachel    | Howell   |
```

## Environment Variables

Create an `env.json` file under the `ReqRes.Specs` project.

![env](https://user-images.githubusercontent.com/28589393/221482116-7cbce0fe-6244-4660-952e-c6e7e7fe07c9.png)

```
{
  "BASE_URL": "https://reqres.in",
  "EMAIL": "youremail@domain.com",
  "PASSWORD": "yoursecret"
}
```

The file only creates runtime env vars. It is automatically ignored by Git and no sensitive data is committed to the repository.

## GitHub Actions

Configuration variables and secrets are now [managed at CI-level](https://docs.github.com/en/actions/learn-github-actions/variables#creating-configuration-variables-for-a-repository).

![vars](https://user-images.githubusercontent.com/28589393/221486106-b90455c5-3e61-49d0-aea4-dc9cab6c61e9.png)

![secrets](https://user-images.githubusercontent.com/28589393/221486103-8d66856f-c2eb-42e0-bc92-274a3f1b6b27.png)

`github-actions.yml:`

```
env:
  BASE_URL: ${{ vars.BASE_URL }}
  EMAIL: ${{ vars.EMAIL }}
  PASSWORD: ${{ secrets.PASSWORD }}
```
The secret `PASSWORD` is never exposed.

> **Note:**
> 
> The same feature is present in all major devops products like [Azure Pipelines](https://learn.microsoft.com/en-us/azure/devops/pipelines/process/set-secret-variables?view=azure-devops), [GitLab CI/CD](https://docs.gitlab.com/ee/ci/variables/), and [Bitbucket Pipelines](https://support.atlassian.com/bitbucket-cloud/docs/variables-and-secrets/).
