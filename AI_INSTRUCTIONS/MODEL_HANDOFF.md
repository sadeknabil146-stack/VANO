# Model Handoff Protocol — VANO: Last Ride

How to transfer work between AI models, sessions, or usage limits without losing progress.

## 1. Starting a session (mandatory reads)

Every model must read, in order:
1. `AI_INSTRUCTIONS/PROJECT_RULES.md`
2. `DEVELOPMENT/CURRENT_STATUS.md`
3. `DEVELOPMENT/NEXT_TASK.md`
4. `DEVELOPMENT/KNOWN_ISSUES.md`
5. Relevant files under `GAME_DOCUMENTATION/` for the task at hand.

Do not rely on conversation history.

## 2. During work

- Follow `NEXT_TASK.md` unless redirected by the user.
- Keep tasks small and testable.
- Record assumptions as open decisions in `KNOWN_ISSUES.md` rather than silently deciding.
- Never claim completion without testing.

## 3. Ending a session (mandatory writes)

Update before stopping:
- `DEVELOPMENT/CURRENT_STATUS.md`
- `DEVELOPMENT/COMPLETED_TASKS.md` (append completed items with date)
- `DEVELOPMENT/CHANGELOG.md` (if notable changes)
- `DEVELOPMENT/NEXT_TASK.md` (define the next task with acceptance criteria)
- `DEVELOPMENT/KNOWN_ISSUES.md` (new/resolved issues)

## 4. Handoff checklist

- [ ] All code/docs changes saved to files (not just in chat).
- [ ] Status docs updated.
- [ ] Next task clearly defined with acceptance criteria.
- [ ] Open issues recorded.
- [ ] Git commit created if Git is available.
- [ ] No unrecorded in-progress work.

## 5. If context is lost

Reconstruct state from `CURRENT_STATUS.md`, `COMPLETED_TASKS.md`, `CHANGELOG.md`, and Git history. Never guess from memory.