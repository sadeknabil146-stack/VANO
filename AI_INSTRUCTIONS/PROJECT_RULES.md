# Project Rules — VANO: Last Ride

Mandatory for every AI model and contributor working on this project.

## A. AI continuity rules (mandatory)

1. Never depend on conversation history as the only source of project information.
2. Always read `PROJECT_RULES.md` and `CURRENT_STATUS.md` before starting work.
3. Update documentation after completing tasks.
4. Record unfinished work before ending a session.
5. Record errors and unresolved problems in `KNOWN_ISSUES.md`.
6. Never claim a feature is completed without testing it.
7. Never delete or overwrite existing work without permission.
8. Use Git when available to preserve working versions.
9. Keep implementation tasks small and testable.
10. Make it possible for another AI model to continue the project immediately.

## B. Product rules

- Engine: Unity. Language: C#. Platform: Android first.
- No generic AI design. Original, recognizable identity required.
- No Pay-to-Win. Monetization must not affect competitive fairness.
- Characters (Mikiy, Lina) have equal gameplay abilities.
- Avoid copying existing games.

## C. Work protocol

- Read `CURRENT_STATUS.md` and `NEXT_TASK.md` before acting.
- Work on the task defined in `NEXT_TASK.md` unless the user directs otherwise.
- Keep changes small and testable; split large tasks.
- Do not build gameplay, generate scripts, install packages, or create assets during the documentation stage (or when the user restricts it).
- Do not make assumptions about unresolved design decisions; record them in `KNOWN_ISSUES.md`.
- Test before marking complete; record test evidence in `COMPLETED_TASKS.md`.

## D. Documentation update protocol (end of session)

Before ending a session, update:
1. `CURRENT_STATUS.md` — where the project is now.
2. `COMPLETED_TASKS.md` — what was finished (with date).
3. `CHANGELOG.md` — notable changes.
4. `NEXT_TASK.md` — the next actionable task.
5. `KNOWN_ISSUES.md` — new/changed open issues.

## E. Safety

- Never delete or overwrite existing files without explicit permission.
- Prefer additive changes and new files.
- Preserve working versions via Git commits when available.

## F. Language and communication rules (Arabic Egyptian)

These rules are mandatory for every AI model and session. They exist so the project owner (who is not necessarily a professional developer) can follow along in simple Egyptian Arabic.

1. **Always communicate with the project owner in simple, natural Egyptian Arabic (اللهجة المصرية).**
2. **Explain technical terms in English first, then clarify their meaning in Arabic.** Example: "GameObject (عنصر داخل المشهد)".
3. **Do not use overly formal or complex language, and avoid unnecessarily long answers.**
4. **Before executing any important stage, explain what you will do and why.**
5. **Do not make big design decisions on your own. Discuss them with the owner first.**
6. **If more than one solution exists, explain the difference between them and recommend the best one.**
7. **Do not assume the owner is a professional developer; explain things in an understandable way.**
8. **At the end of every stage, report what was done and what remains.**

### File and code naming rules

- **Keep file names in English** (e.g., `GAME_VISION.md`, `PlayerController.cs`).
- **Keep programming terms, variable names, and class names in English** — never translate them.
- **Write explanations and documentation in simple Arabic**, keeping English technical terms where needed.
- **Code comments may be bilingual**, but identifiers stay in English.

### Documentation language

- Explanations and guidance: simple Arabic.
- Technical terms, identifiers, file names, API names: English.
- Mixed example: "أنشئ كلاس (class) باسم `PlayerMovement` للتحكم في حركة اللاعب."