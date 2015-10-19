#
# Generated Makefile - do not edit!
#
# Edit the Makefile in the project folder instead (../Makefile). Each target
# has a -pre and a -post target defined where you can add customized code.
#
# This makefile implements configuration specific macros and targets.


# Environment
MKDIR=mkdir
CP=cp
GREP=grep
NM=nm
CCADMIN=CCadmin
RANLIB=ranlib
CC=gcc
CCC=g++
CXX=g++
FC=gfortran
AS=as

# Macros
CND_PLATFORM=MinGW-Windows
CND_DLIB_EXT=dll
CND_CONF=Debug
CND_DISTDIR=dist
CND_BUILDDIR=build

# Include project Makefile
include Makefile

# Object Directory
OBJECTDIR=${CND_BUILDDIR}/${CND_CONF}/${CND_PLATFORM}

# Object Files
OBJECTFILES= \
	${OBJECTDIR}/CirclePerimeterAndArea.o \
	${OBJECTDIR}/FibonacciNumbers.o \
	${OBJECTDIR}/FormattingNumbers.o \
	${OBJECTDIR}/NumbersFromOneToN.o \
	${OBJECTDIR}/NumbersInIntervalDevidableByGivenNumber.o \
	${OBJECTDIR}/PrintCompanyInformation.o \
	${OBJECTDIR}/SumFromOneToN.o \
	${OBJECTDIR}/SumOfFiveNumbers.o \
	${OBJECTDIR}/SumOfNNumbers.o \
	${OBJECTDIR}/SumOfThreeNumbers.o


# C Compiler Flags
CFLAGS=

# CC Compiler Flags
CCFLAGS=
CXXFLAGS=

# Fortran Compiler Flags
FFLAGS=

# Assembler Flags
ASFLAGS=

# Link Libraries and Options
LDLIBSOPTIONS=

# Build Targets
.build-conf: ${BUILD_SUBPROJECTS}
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_3_formatted_input_output.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_3_formatted_input_output.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_3_formatted_input_output ${OBJECTFILES} ${LDLIBSOPTIONS}

${OBJECTDIR}/CirclePerimeterAndArea.o: CirclePerimeterAndArea.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/CirclePerimeterAndArea.o CirclePerimeterAndArea.c

${OBJECTDIR}/FibonacciNumbers.o: FibonacciNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/FibonacciNumbers.o FibonacciNumbers.c

${OBJECTDIR}/FormattingNumbers.o: FormattingNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/FormattingNumbers.o FormattingNumbers.c

${OBJECTDIR}/NumbersFromOneToN.o: NumbersFromOneToN.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/NumbersFromOneToN.o NumbersFromOneToN.c

${OBJECTDIR}/NumbersInIntervalDevidableByGivenNumber.o: NumbersInIntervalDevidableByGivenNumber.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/NumbersInIntervalDevidableByGivenNumber.o NumbersInIntervalDevidableByGivenNumber.c

${OBJECTDIR}/PrintCompanyInformation.o: PrintCompanyInformation.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/PrintCompanyInformation.o PrintCompanyInformation.c

${OBJECTDIR}/SumFromOneToN.o: SumFromOneToN.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/SumFromOneToN.o SumFromOneToN.c

${OBJECTDIR}/SumOfFiveNumbers.o: SumOfFiveNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/SumOfFiveNumbers.o SumOfFiveNumbers.c

${OBJECTDIR}/SumOfNNumbers.o: SumOfNNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/SumOfNNumbers.o SumOfNNumbers.c

${OBJECTDIR}/SumOfThreeNumbers.o: SumOfThreeNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/SumOfThreeNumbers.o SumOfThreeNumbers.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_3_formatted_input_output.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
