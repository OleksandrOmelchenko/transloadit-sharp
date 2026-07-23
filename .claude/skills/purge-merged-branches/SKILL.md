---
name: purge-merged-branches
description: Clean up local git branches whose remote branch was deleted (e.g. after their PR merged). Use when the user wants to remove stale/merged/gone branches, tidy up local branches, or prune after merging PRs.
---

# Purge merged/gone local branches

After a PR merges and its remote branch is deleted, the local branch that tracked it becomes stale (its upstream shows `[gone]`). This removes those.

## Steps

1. Make sure the working tree is clean and switch to a keep-around branch (usually `master`) so you're not sitting on one about to be deleted:
   ```sh
   git checkout master && git pull --ff-only
   ```

2. Run the repo script (prunes remote-tracking refs, then force-deletes every local branch whose upstream is gone; never deletes the current branch):
   ```sh
   sh scripts/purge-merged-branches.sh            # delete
   sh scripts/purge-merged-branches.sh --dry-run  # preview only
   ```

3. Confirm what's left with `git branch`.

## Notes

- "Gone" means the upstream was deleted on the remote — normally because the PR merged. Branches without an upstream (never pushed) are **not** touched, and neither are branches whose remote still exists (e.g. open PRs).
- The script uses `git branch -D` (force) because squash/rebase merges leave the local tip not-an-ancestor of `master`; the `[gone]` upstream is the safe signal that the work already landed. If you want extra caution, run `--dry-run` first.
- The equivalent one-liner, if you don't want the script:
  ```sh
  git fetch --prune && git for-each-ref --format '%(refname:short) %(upstream:track)' refs/heads \
    | awk '$2=="[gone]"{print $1}' | xargs -r git branch -D
  ```
