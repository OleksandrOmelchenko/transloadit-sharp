#!/usr/bin/env sh
#
# Purge local branches whose upstream has been deleted on the remote.
#
# After a pull request is merged and its remote branch is deleted, the local
# branch that tracked it shows as "[gone]". This script prunes stale remote
# tracking refs, then force-deletes those gone local branches. The current
# branch is never deleted.
#
# Usage:
#   sh scripts/purge-merged-branches.sh          # delete gone branches
#   sh scripts/purge-merged-branches.sh --dry-run  # list them without deleting
#
set -eu

dry_run=0
[ "${1:-}" = "--dry-run" ] && dry_run=1

# prune remote-tracking refs that no longer exist on the remote
git fetch --prune

current=$(git rev-parse --abbrev-ref HEAD)

# a branch is "gone" when its configured upstream no longer exists
gone=$(git for-each-ref --format '%(refname:short) %(upstream:track)' refs/heads \
  | awk '$2 == "[gone]" { print $1 }')

if [ -z "$gone" ]; then
  echo "No gone branches to purge."
  exit 0
fi

for branch in $gone; do
  if [ "$branch" = "$current" ]; then
    echo "skip (current branch): $branch"
    continue
  fi
  if [ "$dry_run" -eq 1 ]; then
    echo "would delete: $branch"
  else
    git branch -D "$branch"
  fi
done
