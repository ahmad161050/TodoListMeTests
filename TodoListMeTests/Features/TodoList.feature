Feature: Todo List Management
  As a user, I want to manage my tasks efficiently on TodoListMe by creating, deleting, copying, and organizing my lists.

  # A user should be able to create a new task in the "Today's Tasks" list.
  Scenario: Create a new task in Today's Tasks list
    Given I open the TodoList application
    When I add a new task "Playing Football" to the list "Today's Tasks"
    Then the task "Playing Football" should be displayed in the list "Today's Tasks"

  # A user should be able to remove/delete a task they created in "Today's Tasks".
  Scenario: Delete a newly created task from the To-Do list
    Given I open the TodoList application
    When I add a new task "Doing workout at the gym" to the list "Today's Tasks"
    Then the task "Doing workout at the gym" should be displayed in the list "Today's Tasks"
    When I delete the task "Doing workout at the gym" from the list "Today's Tasks"
    Then the task "Doing workout at the gym" should not be displayed in the list "Today's Tasks"

  # A user should be able to mark a task as completed, moving it to the "Done" section.
  Scenario: Mark a task as done
    Given I open the TodoList application
    And I add a new task "Complete Assignment" to the list "Today's Tasks"
    When I mark the task "Complete Assignment" as done
    Then the task "Complete Assignment" should be moved to the "Done" section

  # A user should be able to move a completed task back to "Today's Tasks".
  Scenario: Unmark a completed task to move it back to To-Do list
    Given I open the TodoList application
    And I have a completed task "Review Report" in the "Done" section
    When I unmark the task "Review Report"
    Then the task "Review Report" should be moved back to the "Today's Tasks" list

  # A user should be able to delete a completed task from the "Done" section.
  Scenario: Delete a done task
    Given I open the TodoList application
    And I mark the task "Completed Task" as done
    When I delete the done task "Completed Task"
    Then the task "Completed Task" should not be displayed in the "Done" section

  # A user should be able to create a new task list.
  Scenario: Create a new list
    Given I open the TodoList application
    When I create a new list named "Personal Tasks"
    Then the list "Personal Tasks" should be displayed in the sidebar

  # A user should be able to delete a list they created.
  Scenario: Delete a list
    Given I open the TodoList application
    And I have a list named "Temporary List"
    When I delete the list "Temporary List"
    Then the list "Temporary List" should not be displayed in the sidebar

  # A user should be able to duplicate an existing list.
  Scenario: Copy an existing list
    Given I open the TodoList application
    And I have a list named "Work Tasks"
    When I copy the list "Work Tasks"
    Then a new list should be created with the name "Copy of Work Tasks"

  # A user should be able to create a new category for organizing lists.
  Scenario: Delete a category
    Given I open the TodoList application
    And I create a new category named "Shopping"
    When I delete the category "Shopping"
    Then the category "Shopping" should not be displayed in the sidebar

  # Sorting Lists
  # A user should be able to sort tasks in alphabetical order.
  Scenario: Sort the list in alphabetical order
    Given I open the TodoList application
    And I have a list with multiple tasks
    When I sort the list by alphabetical order
    Then the tasks should be displayed in alphabetical order

  # A user should be able to restore the normal order of tasks.
  Scenario: Sort the list in normal order
    Given I open the TodoList application
    And I have a list with multiple tasks
    When I sort the list by normal order
    Then the tasks should be displayed in the original order

  # A user should be able to bring top-priority tasks to the top.
  Scenario: Sort the list by top 3 priority items
    Given I open the TodoList application
    And I have a list with multiple tasks
    When I sort the list to display top 3 priority items
    Then the top 3 priority items should be displayed at the top

  # A user should be able to randomly shuffle the order of tasks.
  Scenario: Sort the list randomly
    Given I open the TodoList application
    And I have a list with multiple tasks
    When I sort the list randomly
    Then the tasks should be displayed in a random order

  # A user should be able to open a list in a new browser window.
  Scenario: Open a list in a new window
    Given I open the TodoList application
    And I have a list named "Important Info"
    When I open the list "Important Info" in a new window
    Then the list "Important Info" should be displayed in the new window

  # A user should be able to print the list.
  Scenario: Print the list
    Given I open the TodoList application
    And I have a list named "Weekly Plan"
    When I print the list "Weekly Plan"
    Then a print preview should be displayed
