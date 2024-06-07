# speaker: Slim
VAR finished_computer = false
VAR active_computer = false

There was an accident.

* "What did you see?"
    -> AskWhatSee
* "I don't care"
    -> Cancel
* {finished_computer} "I found the computer"
    -> FoundComputer

=== AskWhatSee ===
# addQuest Computer
Two space ships crashed into each other. There was a corrupt business man on that ship. Collect his briefcase computer as evidence so we can put that thug behind bars. Be careful of the corrupt police drones.

-> END

=== Cancel ===
Talk to me again when you do care.
-> END

=== FoundComputer ===
# completeQuest Computer
Good job. I'll take that from you.
    -> END
