# Secret Scanning + Push Protection Demo

> This repository is intentionally insecure for GitHub Advanced Security demonstrations. Never reuse these patterns in a real application.

## 1. Enable the features

1. Open **Settings** for `GH-500-Org/GH-500-codescanning-demo`.
2. Go to **Advanced Security** or **Code security and analysis**.
3. Enable **Secret scanning**.
4. Enable **Push protection** for supported secrets.

## 2. Trigger a safe demo push protection event

1. Create a temporary demo branch locally.
2. Add a throwaway file such as `demo-secret.txt`.
3. Paste a clearly fake, documented example credential such as the AWS documentation sample values, but keep them obfuscated in this repository documentation. For a local-only demo, reconstruct the access key from `AKIA[IOSFODNN7EXAMPLE]` and the secret from `wJalrXUtnFEMI/K7MDENG/bPxRfiCY[EXAMPLEKEY]` by removing the brackets in your throwaway file.
4. Commit the file on the demo branch and attempt to push it.
5. Push protection should block the push and explain what was detected.

## 3. Show where alerts appear

1. Open the repository **Security** tab.
2. Select **Secret scanning** to view alerts.
3. Open an alert to review the detected secret, location, and remediation options.

## 4. Resolve or close the demo alert

1. Remove the fake secret from the branch or rewrite the demo branch before merging.
2. Re-push the cleaned branch.
3. In **Security → Secret scanning**, resolve the alert with the appropriate resolution once the secret is removed or the demo is complete.

## 5. Existing demo finding already in the repo

`Pages/Index.cshtml` already contains an intentionally hardcoded key for the secret-scanning demo. Leave that value untouched so it can be used as an example finding during the walkthrough.
