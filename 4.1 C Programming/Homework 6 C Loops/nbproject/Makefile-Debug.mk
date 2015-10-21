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
	${OBJECTDIR}/1\ NumbersFromOneToN.o \
	${OBJECTDIR}/10\ OddAndEvenProduct.o \
	${OBJECTDIR}/11\ RandomNumbersInGivenRange.o \
	${OBJECTDIR}/12\ RandomizeTheNumbers.o \
	${OBJECTDIR}/13\ BinaryToDecimalNumber.o \
	${OBJECTDIR}/14\ Decimal\ to\ Binary\ Number.o \
	${OBJECTDIR}/15\ Hexadecimal\ to\ Decimal\ Number.o \
	${OBJECTDIR}/16\ Decimal\ to\ Hexadecimal\ Number.o \
	${OBJECTDIR}/17\ Calculate\ GCD.o \
	${OBJECTDIR}/18\ Trailing\ Zeroes\ in\ N.o \
	${OBJECTDIR}/19\ Spiral\ Matrix.o \
	${OBJECTDIR}/2\ NumbersNotDivisableByThreeAndSeven.o \
	${OBJECTDIR}/3\ MinMaxSumAndAverageOfNNumbers.o \
	${OBJECTDIR}/4\ PrintADeskOf52Cards.o \
	${OBJECTDIR}/5\ CalculateExpression.o \
	${OBJECTDIR}/6\ CalculateExpression2.o \
	${OBJECTDIR}/7\ CalculateExpression3.o \
	${OBJECTDIR}/8\ CatalanNumbers.o \
	${OBJECTDIR}/9\ MatrixOfNumbers.o


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
	"${MAKE}"  -f nbproject/Makefile-${CND_CONF}.mk ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_6_c_loops.exe

${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_6_c_loops.exe: ${OBJECTFILES}
	${MKDIR} -p ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}
	${LINK.c} -o ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_6_c_loops ${OBJECTFILES} ${LDLIBSOPTIONS}

.NO_PARALLEL:${OBJECTDIR}/1\ NumbersFromOneToN.o
${OBJECTDIR}/1\ NumbersFromOneToN.o: 1\ NumbersFromOneToN.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/1\ NumbersFromOneToN.o 1\ NumbersFromOneToN.c

.NO_PARALLEL:${OBJECTDIR}/10\ OddAndEvenProduct.o
${OBJECTDIR}/10\ OddAndEvenProduct.o: 10\ OddAndEvenProduct.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/10\ OddAndEvenProduct.o 10\ OddAndEvenProduct.c

.NO_PARALLEL:${OBJECTDIR}/11\ RandomNumbersInGivenRange.o
${OBJECTDIR}/11\ RandomNumbersInGivenRange.o: 11\ RandomNumbersInGivenRange.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/11\ RandomNumbersInGivenRange.o 11\ RandomNumbersInGivenRange.c

.NO_PARALLEL:${OBJECTDIR}/12\ RandomizeTheNumbers.o
${OBJECTDIR}/12\ RandomizeTheNumbers.o: 12\ RandomizeTheNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/12\ RandomizeTheNumbers.o 12\ RandomizeTheNumbers.c

.NO_PARALLEL:${OBJECTDIR}/13\ BinaryToDecimalNumber.o
${OBJECTDIR}/13\ BinaryToDecimalNumber.o: 13\ BinaryToDecimalNumber.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/13\ BinaryToDecimalNumber.o 13\ BinaryToDecimalNumber.c

.NO_PARALLEL:${OBJECTDIR}/14\ Decimal\ to\ Binary\ Number.o
${OBJECTDIR}/14\ Decimal\ to\ Binary\ Number.o: 14\ Decimal\ to\ Binary\ Number.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/14\ Decimal\ to\ Binary\ Number.o 14\ Decimal\ to\ Binary\ Number.c

.NO_PARALLEL:${OBJECTDIR}/15\ Hexadecimal\ to\ Decimal\ Number.o
${OBJECTDIR}/15\ Hexadecimal\ to\ Decimal\ Number.o: 15\ Hexadecimal\ to\ Decimal\ Number.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/15\ Hexadecimal\ to\ Decimal\ Number.o 15\ Hexadecimal\ to\ Decimal\ Number.c

.NO_PARALLEL:${OBJECTDIR}/16\ Decimal\ to\ Hexadecimal\ Number.o
${OBJECTDIR}/16\ Decimal\ to\ Hexadecimal\ Number.o: 16\ Decimal\ to\ Hexadecimal\ Number.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/16\ Decimal\ to\ Hexadecimal\ Number.o 16\ Decimal\ to\ Hexadecimal\ Number.c

.NO_PARALLEL:${OBJECTDIR}/17\ Calculate\ GCD.o
${OBJECTDIR}/17\ Calculate\ GCD.o: 17\ Calculate\ GCD.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/17\ Calculate\ GCD.o 17\ Calculate\ GCD.c

.NO_PARALLEL:${OBJECTDIR}/18\ Trailing\ Zeroes\ in\ N.o
${OBJECTDIR}/18\ Trailing\ Zeroes\ in\ N.o: 18\ Trailing\ Zeroes\ in\ N.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/18\ Trailing\ Zeroes\ in\ N.o 18\ Trailing\ Zeroes\ in\ N.c

.NO_PARALLEL:${OBJECTDIR}/19\ Spiral\ Matrix.o
${OBJECTDIR}/19\ Spiral\ Matrix.o: 19\ Spiral\ Matrix.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/19\ Spiral\ Matrix.o 19\ Spiral\ Matrix.c

.NO_PARALLEL:${OBJECTDIR}/2\ NumbersNotDivisableByThreeAndSeven.o
${OBJECTDIR}/2\ NumbersNotDivisableByThreeAndSeven.o: 2\ NumbersNotDivisableByThreeAndSeven.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/2\ NumbersNotDivisableByThreeAndSeven.o 2\ NumbersNotDivisableByThreeAndSeven.c

.NO_PARALLEL:${OBJECTDIR}/3\ MinMaxSumAndAverageOfNNumbers.o
${OBJECTDIR}/3\ MinMaxSumAndAverageOfNNumbers.o: 3\ MinMaxSumAndAverageOfNNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/3\ MinMaxSumAndAverageOfNNumbers.o 3\ MinMaxSumAndAverageOfNNumbers.c

.NO_PARALLEL:${OBJECTDIR}/4\ PrintADeskOf52Cards.o
${OBJECTDIR}/4\ PrintADeskOf52Cards.o: 4\ PrintADeskOf52Cards.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/4\ PrintADeskOf52Cards.o 4\ PrintADeskOf52Cards.c

.NO_PARALLEL:${OBJECTDIR}/5\ CalculateExpression.o
${OBJECTDIR}/5\ CalculateExpression.o: 5\ CalculateExpression.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/5\ CalculateExpression.o 5\ CalculateExpression.c

.NO_PARALLEL:${OBJECTDIR}/6\ CalculateExpression2.o
${OBJECTDIR}/6\ CalculateExpression2.o: 6\ CalculateExpression2.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/6\ CalculateExpression2.o 6\ CalculateExpression2.c

.NO_PARALLEL:${OBJECTDIR}/7\ CalculateExpression3.o
${OBJECTDIR}/7\ CalculateExpression3.o: 7\ CalculateExpression3.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/7\ CalculateExpression3.o 7\ CalculateExpression3.c

.NO_PARALLEL:${OBJECTDIR}/8\ CatalanNumbers.o
${OBJECTDIR}/8\ CatalanNumbers.o: 8\ CatalanNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/8\ CatalanNumbers.o 8\ CatalanNumbers.c

.NO_PARALLEL:${OBJECTDIR}/9\ MatrixOfNumbers.o
${OBJECTDIR}/9\ MatrixOfNumbers.o: 9\ MatrixOfNumbers.c 
	${MKDIR} -p ${OBJECTDIR}
	${RM} "$@.d"
	$(COMPILE.c) -g -MMD -MP -MF "$@.d" -o ${OBJECTDIR}/9\ MatrixOfNumbers.o 9\ MatrixOfNumbers.c

# Subprojects
.build-subprojects:

# Clean Targets
.clean-conf: ${CLEAN_SUBPROJECTS}
	${RM} -r ${CND_BUILDDIR}/${CND_CONF}
	${RM} ${CND_DISTDIR}/${CND_CONF}/${CND_PLATFORM}/homework_6_c_loops.exe

# Subprojects
.clean-subprojects:

# Enable dependency checking
.dep.inc: .depcheck-impl

include .dep.inc
